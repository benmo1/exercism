<?php

function distance(string $a, string $b)
{
    if (strlen($a) !== strlen($b)) {
        throw new InvalidArgumentException('DNA strands must be of equal length.');
    }

    for ($d = 0, $i = 0; $i < strlen($a); $i++) {
        $d += $a[$i] !== $b[$i];
    }

    return $d;
}
