<?php

//
// This is only a SKELETON file for the "Hamming" exercise. It's been provided as a
// convenience to get you started writing code faster.
//

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
